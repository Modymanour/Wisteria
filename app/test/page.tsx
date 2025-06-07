'use client';
import Image from "next/image";
import styles from "./page.module.css";

export default function Home() {
  async function test(){
    try{
        
        const url = 'https://localhost:7044/Authentication/Test';
        const res = await fetch(url,{method: 'Post'});
        console.log(res)
        if(!res.ok) throw new Error(`Response status: ${res.status}`);
        console.log(res)
        const session = await res.json(); 
        console.log(session);
      }
      catch(error){
        console.log(error)
      }
    }
  return (
    <div>
      <form action={test}>
        <button>Hi</button>
      </form>
    </div>
  );
}
