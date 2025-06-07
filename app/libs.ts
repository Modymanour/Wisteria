'use server';
import { cookies } from 'next/headers';
import { NextRequest } from 'next/server';
import { NextResponse } from 'next/server';
import {jwtVerify, SignJWT} from 'jose';

const secretkey = process.env.SECRETKEY ?? "";
const key = new TextEncoder().encode(secretkey)

export async function encrypt(payload: any) {
    const token = await new SignJWT(payload)
    .setProtectedHeader({alg:'HS256'})
    .setIssuedAt()
    .setIssuer(process.env.ISSUER ?? "")
    .setAudience(process.env.AUDIENCE ?? "")
    .setExpirationTime(Date.now()+10*1000)
    .sign(key)
    console.log(token)
    return token
}
export async function decrypt(token: string){
    const {payload} = await jwtVerify(token,key,{
        algorithms: ['HS256'],
    })
    return payload;
}
export async function login (prevState: any,formData: FormData) {
    const user = {email: formData.get('Email'),password: formData.get('Password')}
    const url = "https://localhost:7044/Authentication/Login";
    try {
    const res = await fetch(url,{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    if (!res.ok) throw new Error(`Response status: ${res.status}`);

    const session = await res.json();
    console.log(session);
    const expires = new Date(Date.now()+10*1000);
    } catch (error: any) {
    console.error(error.message);
  }
    
}

export async function register(prevState:any,res: Response){
    try{
        const session = await res.json(); 
        console.log(session);
        const expires = new Date(Date.now()+10*1000);
        (await cookies()).set('session',session,{expires,httpOnly:true})
        return "Succesful";
    }    
    catch (error: any) {
    console.error("tragic:",error.message);
    return error.message;
  }
}

export async function getSession(){
    const session = (await cookies()).get('session')?.value;
    if(!session) return null;
    return await decrypt(session);
}

export async function updateSession(request:NextRequest){
    const session = request.cookies.get('session')?.value;
    if(!session) return;
    const parsed = await decrypt(session);
    const res = NextResponse.next();
    res.cookies.set({
        name:'session',
        value: await encrypt(parsed),
        httpOnly: true,
        expires: new Date(Date.now() + 10*1000),
    });
    return res;
}