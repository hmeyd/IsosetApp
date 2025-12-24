// app.js
import { addTask } from './tasks.js';
import { loadTasks } from './storage.js';
import { fetchSuggestions } from './api.js';

const form = document.getElementById('task-form');
const input = document.getElementById('task-input');




form.addEventListener('submit', (e) => {
    e.preventDefault();
    const taskTitle = input.value.trim();
    if (taskTitle) {
        addTask(taskTitle, true);
        input.value = '';
    }
});

loadTasks();

(async () => {
    const suggestions = await fetchSuggestions();
    suggestions.forEach(title => addTask(title, false));
})();



