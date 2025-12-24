import { addTask } from './tasks.js';

export function saveTasks() {
    const tasks = [];
    document.querySelectorAll('.task-item span').forEach(span => {
        tasks.push(span.textContent);
    });
    localStorage.setItem('tasks', JSON.stringify(tasks));
}

export function loadTasks() {
    const tasks = JSON.parse(localStorage.getItem('tasks')) || [];
    tasks.forEach(title => addTask(title, false));
}
