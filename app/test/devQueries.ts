"use server"
export async function getUsers() {
    try{
        const url = 'https://localhost:7044/Get/Users';
        const res = await fetch(url,{method: 'GET'});
        if(!res.ok) throw new Error(`Response status: ${res.status}`);
        console.log(res)
        const data = await res.json(); 
        console.log(data);
        return data;
      }
      catch(error){
        console.log(error)
        return ";"
    }
}