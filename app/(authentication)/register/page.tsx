"use client";
import "@/app/(authentication)/register.css";
import W from "@/app/letter-w.png"
import Redirect from "@/app/(authentication)/right-up.png";
import Image from "next/image";
import { register } from "@/app/libs";
import { redirect } from 'next/dist/server/api-utils';
import { useActionState,startTransition, useState } from 'react';

// export const experimental_ppr = true;


export default function Page(){
    const [state,registerAction] = useActionState(register,undefined);
    const [nameError,nameSet] = useState("")
    const [emailError,emailSet] = useState("")
    const [passwordError,passwordSet] = useState("")
    const [confirmError,confirmSet] = useState("")
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
                    confirmSet("Passwords dont match")
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
                const data = await res.json()
                if (data?.token){
                    nameSet("")
                    emailSet("")
                    passwordSet("")
                    confirmSet("")
                    console.log("Succesful")
                    startTransition(() => registerAction(data.token))
                    console.log("Success")
                    return
                }
                if(data.error === "Email is invalid"){
                        nameSet("")
                        passwordSet("")
                        confirmSet("")
                        console.log(data.error)
                        emailSet(data.error)
                        return
                }
                else if(data.error === "Password is invalid"){
                    nameSet("")
                    emailSet("")
                    confirmSet("")
                    console.log(data.error)
                    passwordSet("Password has to have 1 upprecase letter and be 8 characters long ")
                    return
                }
                else if(data.error === "Both the Email & Password are invalid"){
                    console.log(data.error)
                    nameSet("")
                    confirmSet("")
                    emailSet("Email is invalid")
                    passwordSet("Password has to have 1 upprecase letter and be 8 characters long ")
                    return
                }
                else if(data.error === "Name is already taken"){
                    console.log(data.error)
                    emailSet("")
                    passwordSet("")
                    confirmSet("")
                    nameSet(data.error)
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
                        <a href="http://localhost:3000/login" className="WistLogIn" title="Redirect to Login">
                        <Image src={Redirect} width={10} height={10} alt=""/>
                        Login
                        </a>
                    </div>
                    <div className="topText">
                        <h3>Create your Wisteria Account</h3>
                    </div>
                    <div>
                        <div className="textRow">
                            <div className="typeText">Username</div>
                            {nameError && (
                            <div className="errorNameText">{nameError}</div>
                            )}
                        </div>
                        <label htmlFor="Username"></label>
                        <input type="text" name="Username" id="Username" placeholder="" required className="typeBox"></input>
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
                        <div className="textRow">
                            <div className="typeText">Confirm Password</div>
                            {confirmError && (
                            <div className="errorConfirmText">{confirmError}</div>
                            )}
                        </div>
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