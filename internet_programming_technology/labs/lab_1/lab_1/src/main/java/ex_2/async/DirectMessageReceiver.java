package ex_2.async;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import ex_2.FootballTeam;

import javax.jms.*;

public class DirectMessageReceiver implements MessageListener {
    ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();
    JMSConsumer consumer;

    DirectMessageReceiver(){
        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676,mq://127.0.0.1:7676");
            Destination cardsQueue = context.createQueue("Ex_2");

            consumer = context.createConsumer(cardsQueue);
            consumer.setMessageListener(this);

            System.out.println("Listening to Ex_2...");

            while (true) {
                Thread.sleep(1000);
            }
        } catch (InterruptedException e){
            System.out.println("Error: " + e.getMessage());
        }
        catch (JMSException e){
            System.out.println("Error: " + e.getMessage());
        }
    }

    @Override
    public void onMessage(javax.jms.Message message) {
        try {
            System.out.println("Сообщение: "+
                    message.getBody(FootballTeam.class));
            System.out.println("\nВот что такое toString () для печати сообщения \n"+ message);

        } catch (Exception e) {
            System.err.println("JMSException: " + e.toString());
        }
    }

    public static void main (String[] args){
        new DirectMessageReceiver();
    }
}
