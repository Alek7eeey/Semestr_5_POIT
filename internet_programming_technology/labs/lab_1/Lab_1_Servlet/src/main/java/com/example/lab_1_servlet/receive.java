package com.example.lab_1_servlet;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import com.sun.messaging.Destination;
import com.sun.messaging.jmq.jmsservice.Consumer;
import javax.jms.*;

public class receive implements MessageListener {

    ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();
    JMSConsumer consumer;
    receive(){
        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination info =(Destination) context.createQueue("Servlet");
            consumer = context.createConsumer(info);
            consumer.setMessageListener(this);

            System.out.println("Listening to servlet...");

            // wait for messages
            Thread.sleep(100000);

        } catch (JMSException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void onMessage(Message message) {
        try{
            System.out.println("Message from servlet: " + message.getBody(String.class));
        } catch (JMSException e){
            System.err.println("JMSException: " + e.toString());
        }
    }

    public static void main(String[] args) {
        new receive();
    }

}
