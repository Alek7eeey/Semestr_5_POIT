const { send } = require('./m06_kad')

const senderEmail = 'TaskWave@outlook.com';
const password = 'TWPassword';
const recipientEmail = "alekseykravchenko120@gmail.com";
const message = "Hello!";
const result = send(senderEmail, password, message, recipientEmail);

console.log('Результат отправки:', result);