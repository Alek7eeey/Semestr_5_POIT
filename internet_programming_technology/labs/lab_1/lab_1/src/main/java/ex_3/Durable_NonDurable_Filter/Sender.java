package ex_3.Durable_NonDurable_Filter;

import com.sun.messaging.ConnectionConfiguration;
import com.sun.messaging.ConnectionFactory;

import javax.jms.Destination;
import javax.jms.JMSContext;
import javax.jms.JMSException;
import javax.jms.TextMessage;

public class Sender {
    public static void main(String[] args){
        ConnectionFactory factory = new com.sun.messaging.ConnectionFactory();

        try(JMSContext context = factory.createContext("admin", "admin")){
            factory.setProperty(ConnectionConfiguration.imqAddressList, "mq://127.0.0.1:7676, mq://127.0.0.1:7676");
            Destination priceInfo  = context.createTopic("Ex3_3");
            TextMessage outMsg = context.createTextMessage();
            outMsg.setText("PNV 100 2536721");
            outMsg.setStringProperty("symbol", "BSTU");
            context.createProducer().send(priceInfo, outMsg);
            System.out.println("message has been sent");

        } catch (JMSException e) {
            throw new RuntimeException(e);
        }
    }
}
