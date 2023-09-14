package ex_2;

import java.io.Serializable;

public class FootballTeam implements Serializable {
    private int id;

    private String name;
    private String country;
    private int countOfPlayers;

    public FootballTeam(){
        id = -1;
        name = "";
        country = "";
        countOfPlayers = 0;
    }
    /**DEFAULT CREATE*/
    public FootballTeam(String name, String country, int countOfPlayers) {
        this.name = name;
        this.country = country;
        this.countOfPlayers = countOfPlayers;
    }
    /**DATABASE CREATE*/
    public FootballTeam(int id, String name, String country, int countOfPlayers){
        this.id = id;
        this.name = name;
        this.country = country;
        this.countOfPlayers = countOfPlayers;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getCountOfPlayers() {
        return countOfPlayers;
    }
    public String getCountry() {
        return country;
    }

    @Override
    public String toString() {
        return "ex_2.Operator{" +
                "id=" + id +
                ", name of football club='" + name + '\'' +
                ", country='" + country + '\'' +
                ", countOfPlayers=" + countOfPlayers +
                '}';
    }
}
