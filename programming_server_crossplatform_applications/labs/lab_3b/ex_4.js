import crypto from "crypto";

const validateCard = (numberOfCard) => {
    console.log("Card number: " + numberOfCard);
    return Math.floor( Math.random() * 1000000 ) % 2 === 0;
};

const proceedToPayment = async (id) =>{
    console.log("Order ID: " + id);
    if(Math.floor( Math.random() * 1000000 ) % 2 === 0){
        console.log("Payment Successful");
    }else {
        console.log("Payment Failed");
    }
};

const createOrder = async (numberOfCard)=>{
    return new Promise((resolve, reject)=>{
        if(validateCard(numberOfCard)){
            setTimeout(()=>{
                const id = crypto.randomBytes(16).toString("hex");
                resolve(id);
            }, 5000)
        }
        else {
            reject("Card is not valid");
        }
    })
}

// createOrder("1234 5678 9123 456")
//     .then(async (result) => {
//         await proceedToPayment(result);
//     })
//     .catch((err)=>{
//         console.warn(err);
//     })

try{
    const res = await createOrder("1234 5678 9123 456");
    await proceedToPayment(res);
}
catch (e){
    console.warn(e);
}