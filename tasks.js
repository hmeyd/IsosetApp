import { saveTasks } from './storage.js';

export function addTask(title, save = true) {
    if (!title) return;

    const li = document.createElement('li');
    li.classList.add('task-item');

    li.innerHTML = `
        <span>${title}</span>
        <button class="delete-btn">Supprimer</button>
    `;

    li.querySelector('.delete-btn').addEventListener('click', () => {
        li.remove();
        saveTasks();
    });

    document.getElementById('task-list').appendChild(li);

    if (save) {
        saveTasks();
    }
}
