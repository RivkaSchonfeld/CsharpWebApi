import axios from "axios"

const url = "https://localhost:7071/api/Client"

export const getAllClients = async () => {
    try {
        const list = await axios.get(url)
        console.log("list", list.data)
        return list.data

    }
    catch (ex) {
        console.log(ex)
        return "hello"
    }



}