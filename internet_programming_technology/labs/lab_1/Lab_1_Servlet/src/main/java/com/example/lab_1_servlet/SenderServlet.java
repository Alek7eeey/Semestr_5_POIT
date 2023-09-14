package com.example.lab_1_servlet;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;

import javax.jms.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;

@WebServlet(name = "SenderServlet", value = "/SenderServlet")
public class SenderServlet extends HttpServlet{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        ConnectionFactory factory = new ConnectionFactory();

        try (JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676, mq://127.0.0.1:7676");

            Destination cardsQueue = context.createQueue("Servlet");
            JMSProducer producer = context.createProducer();

            producer.send(cardsQueue, request.getParameter("message"));

            System.out.println("Placed an information about card transaction to BankCardQueue");
        }
        catch (JMSException err) {
            System.out.println(err.getMessage());
        }

        response.sendRedirect("");
    }
}
