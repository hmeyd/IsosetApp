// api.js
export async function fetchSuggestions(limit = 5) {
    try {
        const response = await fetch(`https://jsonplaceholder.typicode.com/todos?_limit=${limit}`);
        if (!response.ok) throw new Error('Erreur lors de la récupération des tâches');
        const data = await response.json();
        return data.map(item => item.title);
    } catch (error) {
        console.error(error);
        alert("Impossible de récupérer les suggestions de tâches !");
        return [];
    }
}
