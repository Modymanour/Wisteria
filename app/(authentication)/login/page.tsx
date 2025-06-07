"use client";
import "@/app/(authentication)/login.css";
import W from "@/app/(authentication)/letter-w.png"
import Redirect from "@/app/(authentication)/right-up.png"
import Image from "next/image";
import { login, register } from "@/app/libs";
import { redirect } from 'next/dist/server/api-utils';
import { useActionState,startTransition, useState } from 'react';
import { useRouter } from "next/router";

// export const experimental_ppr = true;


export default function Page(){
    const [state,loginAction] = useActionState(login,undefined);
    const [emailError,emailSet] = useState("")
    const [passwordError,passwordSet] = useState("")
    async function stopRefresh(e:React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        const form = e.currentTarget;
        const data = new FormData(form);
        handleRegister(data)
    }
    async function handleRegister(formData: FormData){
        
        try{
                const user = {email: formData.get('Email')as string,
                    password:formData.get('Password')as string};
                console.log(user);
                const url = 'https://localhost:7044/Authentication/Login';
                const res = await fetch(url,{
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(user),
            });
                console.log(res)
                const data = await res.json()
                if (data?.token){
                    emailSet("")
                    passwordSet("")
                    console.log("Succesful")
                    startTransition(() => loginAction(data.token))
                    console.log("Success")
                    return
                }
                if(data.error === "Email not found"){
                        passwordSet("")
                        console.log(data.error)
                        emailSet(data.error)
                        return
                }
                else if(data.error === "Wrong Password"){
                    emailSet("")
                    console.log(data.error)
                    passwordSet(data.error)
                    return
                }// redirect('/');
            }    
            catch (error: any) {
                console.log("error happened", error)
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
                        <a href="http://localhost:3000/register" className="WistLogIn" title="Redirect to register">
                        <Image src={Redirect} width={10} height={10} alt=""/>
                        Sign up
                        </a>
                    </div>
                    <div className="topText">
                        <h3>Login into your Wisteria Account</h3>
                    </div>
                    <div>
                        <div className="textRow">
                            <div className="typeText">Email</div>
                            {emailError && (
                            <div className="errorEmailText">{emailError}</div>
                            )}
                        </div>
                        <label htmlFor="Email"></label>
                        <input type="text" name="Email" id="Email" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <div className="textRow">
                            <div className="typeText">Password</div>
                            {passwordError && (
                            <div className="errorPasswordText">{passwordError}</div>
                            )}
                        </div>
                        <label htmlFor="Password"></label>
                        <input type="text" name="Password" id="Password" placeholder="" required className="typeBox"></input>
                    </div>
                    <div>
                        <button  className="registerButton" type="submit">Sign in</button>                    
                    </div>
                </form>
        </div>
    );
}