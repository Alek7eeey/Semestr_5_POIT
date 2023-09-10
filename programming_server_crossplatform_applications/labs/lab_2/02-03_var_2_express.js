const express = require('express');
const app = express();

app.get('/api/name', (req, res) => {
    const fullName = 'Kravchenko Aleksey Dmitrievich';
    res.type('text').send(fullName);
});

app.listen(5000, () => {
    console.log('Сервер запущен на порту 5000');
});