package ex_3.Durable_NonDurable_Filter;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;

import javax.jms.*;

public class Receiver_1 implements MessageListener {
    ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

    Receiver_1(){
        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676, mq://127.0.0.1:7676");
            Destination info = context.createTopic("Ex_3_3");
            //context.setClientID("client123");
            JMSConsumer consumer = context.createConsumer(info);
            consumer.setMessageListener(this);

            while (true) {
                Thread.sleep(1000);
            }

        } catch (JMSException e) {
            throw new RuntimeException(e);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void onMessage(Message message){
        try{
            System.out.println("Receiver 1: " + message.getBody(String.class));
        } catch (JMSException e) {
            throw new RuntimeException(e);
        }
    }

    public static void main (String[] args){
        new Receiver_1();
    }
}
