
const API_BASE = '';
const modal = new bootstrap.Modal(document.getElementById('updateModal'));

async function loadTodos(filters = {}) {
    console.log(filters);
    const res = await fetch(`${API_BASE}/api/Todos/Get`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(filters)
    });
    console.log(res);
    const data = await res.json();
    const list = document.getElementById('todoList');
    list.innerHTML = '';

    if (data.todos?.length) {
        data.todos.forEach(todo => {
            const card = document.createElement('div');
            card.className = 'col';
            card.innerHTML = `
        <div class="card shadow-sm">
          <div class="card-body">
            <h5 class="card-title">${todo.title}</h5>
            <p>${todo.description || ''}</p>
            <p>Status: <strong>${todo.status}</strong></p>
            <p>Priority: <strong>${todo.priority}</strong></p>
            <div class="d-flex gap-2">
              <button class="btn btn-success btn-sm" onclick="completeTodo('${todo.id}')">Complete</button>
              <button class="btn btn-warning btn-sm" onclick="openUpdateModal('${todo.id}', '${todo.title}', '${todo.description}', '${todo.status}', '${todo.priority}', '${todo.dueDate ?? ''}')">Edit</button>
              <button class="btn btn-danger btn-sm" onclick="deleteTodo('${todo.id}')">Delete</button>
            </div>
          </div>
        </div>
      `;
            list.appendChild(card);
        });
    } else {
        list.innerHTML = '<p class="text-muted">No todos found.</p>';
    }
}

document.getElementById('filterForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const filters = {
        statusFilter: document.getElementById('filterStatus').value || null,
        priorityFilter: document.getElementById('filterPriority').value || null
    };
    if (document.getElementById('creationFrom').value && document.getElementById('creationTo').value)
        filters.creationDateFilter = {
            from: document.getElementById('creationFrom').value || null,
            to: document.getElementById('creationTo').value || null
        }
    if (document.getElementById('modificationFrom').value && document.getElementById('modificationTo').value)
        filters.modificationDateFilter = {
            from: document.getElementById('modificationFrom').value || null,
            to: document.getElementById('modificationTo').value || null
        }
    await loadTodos(filters);
});

function clearFilters() {
    document.getElementById('filterForm').reset();
    loadTodos();
}

async function addTodo(e) {
    e.preventDefault();
    const title = document.getElementById('title').value;
    const description = document.getElementById('description').value;
    const priority = document.getElementById('priority').value;

    const body = {
        todo: {
            title,
            description,
            priority,
            status: "Pending"
        }
    };

    await fetch(`${API_BASE}/api/Todos/Create`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    });

    document.getElementById('addTodoForm').reset();
    await loadTodos();
}

async function completeTodo(id) {
    await fetch(`${API_BASE}/api/Todos/Complete/${id}`, { method: 'GET' });
    await loadTodos();
}

async function deleteTodo(id) {
    await fetch(`${API_BASE}/api/Todos/Delete/${id}`, { method: 'DELETE' });
    await loadTodos();
}

function openUpdateModal(id, title, description, status, priority, dueDate) {
    document.getElementById('updateId').value = id;
    document.getElementById('updateTitle').value = title;
    document.getElementById('updateDescription').value = description;
    document.getElementById('updateStatus').value = status;
    document.getElementById('updatePriority').value = priority;
    document.getElementById('updateDueDate').value = dueDate ? dueDate.slice(0, 16) : '';

    modal.show();
}

document.getElementById('updateTodoForm').addEventListener('submit', async (e) => {
    e.preventDefault();

    const id = document.getElementById('updateId').value;
    const body = {
        id,
        title: document.getElementById('updateTitle').value,
        description: document.getElementById('updateDescription').value,
        status: document.getElementById('updateStatus').value,
        priority: document.getElementById('updatePriority').value,
        dueDate: document.getElementById('updateDueDate').value || null
    };

    await fetch(`${API_BASE}/api/Todos/Update`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(body)
    });

    modal.hide();
    await loadTodos();
});

document.getElementById('addTodoForm').addEventListener('submit', addTodo);

loadTodos();
