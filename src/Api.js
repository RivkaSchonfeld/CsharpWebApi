import axios from "axios"

const url = "https://localhost:7071/api/Client"

export const getAllClients = async () => {
    try {
        const list = await axios.get(url)
        return list.data

    }
    catch (ex) {
        console.log(ex)
        return []
    }



}

export const getClientById= async (id)=>{
    try{
        const client = await axios.get(url+"/"+id)
        return client.data
    }
    catch(ex){
        console.log(ex)

    }
}