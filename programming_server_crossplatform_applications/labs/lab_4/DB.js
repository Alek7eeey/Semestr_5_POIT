export class user {
    constructor(id, name, dateOfBirth) {
        this.id = id;
        this.name = name;
        this.dateOfBirth = dateOfBirth;
    }
}


export class BD{
    static async select(array){
        return array.sort((a,b)=>a.id-b.id);
    }

    static async insert(row){
        let lastId = Math.max(...database.map(item => item.id), 0) + 1;
        const id = lastId;
        const newRow = { id, ...row };
        database.push(newRow);
        return newRow;
    }

    static async update(newData){
        const index = database.findIndex(item => item.id === Number.parseInt(newData.id));
        if (index !== -1) {
            database.splice(index, 1);
            database.push(newData)
            return database[database.length-1];
        }
        return null;
    }

    static async delete(idD){
        const index = database.findIndex(item => item.id === Number.parseInt(idD));
        if (index !== -1) {
            return database.splice(index, 1)[0];
        }
        return null;
    }
}
export let database = [
    new user(1, "Artem", "11-09-2004"),
    new user(2, "Dmitry", "03-03-2003"),
    new user(3, "Aleksey", "01-12-1998"),
    new user(4, "Daria", "11-01-2007"),
    new user(5, "Alex", "11-01-1955")
];
