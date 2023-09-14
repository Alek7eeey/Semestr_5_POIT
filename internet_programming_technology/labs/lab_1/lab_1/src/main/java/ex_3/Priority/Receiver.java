package ex_3.Priority;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import javax.jms.*;

public class Receiver implements MessageListener {
    private ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

    private JMSConsumer consumer;

    Receiver() {
        try(JMSContext context = factory.createContext("admin", "admin")) {
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676, mq://127.0.0.1:7676");
            Destination dest = context.createTopic("Ex3_2");
            consumer = context.createConsumer(dest);
            consumer.setMessageListener(this);

            while (true)
            {
                Thread.sleep(1000);
            }
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        } catch (JMSException e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public void onMessage(Message message) {
        try {
            System.out.println("Reciever: "+ message.getBody(String.class));
        } catch (Exception e) {
            System.err.println("JMSException: " + e.toString());
        }
    }

    public static void main (String[] args) throws InterruptedException {
        new Receiver();
    }
}
