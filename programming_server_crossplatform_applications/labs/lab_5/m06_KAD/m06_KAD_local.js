// m06_XXX.js

const nodemailer = require('nodemailer');

const send = (senderEmail, password, message, recipientEmail) => {
    let transporter = nodemailer.createTransport({
        host: 'smtp-mail.outlook.com',
        port: 587,
        secure: false,
        auth: {
            user: senderEmail,
            pass: password,
        },
    });

    transporter.sendMail({
            from: senderEmail,
            to: recipientEmail,
            subject: 'Message from lab_5',
            text: message
    });

    return {
        from: senderEmail,
        to: recipientEmail,
        subject: 'Message from lab_5',
        text: message,
    };
}

module.exports = { send };
