package ex_2.sync;

import javax.jms.*;
import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import ex_2.FootballTeam;

public class DirectMessageReceiverSYNC {
    private ConnectionFactory factory = new ConnectionFactory();
    private JMSConsumer consumer;

    DirectMessageReceiverSYNC() {
        try (JMSContext context = factory.createContext("admin", "admin")) {
            factory.setProperty(ConnectionConfiguration.imqAddressList,
                    "mq://127.0.0.1:7676, mq://127.0.0.1:7676");
            Destination messageQueue = context.createQueue("Ex2_2");

            consumer = context.createConsumer(messageQueue);

            Message message = consumer.receive();

            System.out.println("Listening to Ex_2-2...");
            System.out.println("Сообщение: "+
                    message.getBody(FootballTeam.class));

            System.out.println("\nВот что такое toString () для печати сообщения \n"+ message);

            while (true) {
                Thread.sleep(1000);
            }
        } catch (InterruptedException | JMSException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void main (String[] args){
        new DirectMessageReceiverSYNC();
    }
}
