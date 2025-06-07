"use client";
import "./register.css";
import W from "./letter-w.png"
import Redirect from "./right-up.png"
import Image from "next/image";
import { register } from "../libs";
import { redirect } from 'next/dist/server/api-utils';
import { useActionState,startTransition } from 'react';
import { useRouter } from "next/router";

// export const experimental_ppr = true;


export default function Page(){
    const [state,registerAction] = useActionState(register,undefined);
    async function stopRefresh(e:React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        const form = e.currentTarget;
        const data = new FormData(form);
        handleRegister(data)
    }
    async function handleRegister(formData: FormData){
        try{
                const user = {name: formData.get('Username')as string,
                    email: formData.get('Email')as string,
                    password:formData.get('Password')as string};
                if(user.password != formData.get('ConfirmPassword')){
                    console.log("Confirm Password doesnt match Password");
                    return;
                } 
                console.log(user);
                const url = 'https://localhost:7044/Authentication/Register';
                const res = await fetch(url,{
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(user),
            });
                console.log(res)
                if(!res.ok) throw new Error(`Response status: ${res.statusText}`);
                startTransition(() => registerAction(res))
                console.log("Succesful")
                // redirect('/');
            }    
            catch (error: any) {
            console.error("tragic:",error.message);
            return error.message;
          }
    }
    return(
            <div className="background">
                <form className="Container"onSubmit={stopRefresh} >
                    <div className="Wisteria">
                        <Image 
                        src={W}
                        alt="Wisteria"
                        title="wisteria"
                        width={50}
                        height={50}
                        />
                        <h2 className="WistText">WISTERIA</h2>
                        <a href="http://localhost:3000/login" className="WistLogIn" title="Redirect to Login">
                        <Image src={Redirect} width={10} height={10} alt=""/>
                        Login
                        </a>
                    </div>
                    <div className="topText">
                        <h3>Create your Wisteria Account</h3>
                    </div>
                    <div>
                        <div className="typeText">Username</div>
                        <label htmlFor="Username"></label>
                        <input type="text" name="Username" id="Username" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <div className="typeText">Email</div>
                        <label htmlFor="Email"></label>
                        <input type="text" name="Email" id="Email" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <div className="typeText">Password</div>
                        <label htmlFor="Password"></label>
                        <input type="text" name="Password" id="Password" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <div className="typeText">Confirm Password</div>
                        <label htmlFor="ConfirmPassword"></label>
                        <input type="text" name="ConfirmPassword" id="ConfirmPassword" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <button  className="registerButton" type="submit">Create Account</button>                    
                    </div>
                </form>
        </div>
    );
}