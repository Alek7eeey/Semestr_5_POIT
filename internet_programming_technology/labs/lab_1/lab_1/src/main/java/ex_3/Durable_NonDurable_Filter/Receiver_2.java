package ex_3.Durable_NonDurable_Filter;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;
import javax.jms.*;

public class Receiver_2 implements MessageListener {
    ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();
    private JMSConsumer consumer;

    Receiver_2() {
        try (JMSContext context = factory.createContext("admin", "admin")) {
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676, mq://127.0.0.1:7676");
            Destination priceInfo = context.createTopic("Ex3_3");
            consumer = context.createConsumer(priceInfo);
            String selector = "symbol=BSTU";
            context.createConsumer(priceInfo, selector);

            consumer.setMessageListener(this);
            while (true) {
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
            System.out.println("Reciever 1: "+ message.getBody(String.class) + " " + message.getStringProperty("symbol"));
        } catch (Exception e) {
            System.err.println("JMSException: " + e.toString());
        }
    }

    public static void main (String[] args){
        new Receiver_2();
    }
}
