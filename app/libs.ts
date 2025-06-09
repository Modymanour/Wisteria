'use server';
import { cookies } from 'next/headers';
import { NextRequest } from 'next/server';
import { NextResponse } from 'next/server';
import {jwtVerify, SignJWT} from 'jose';

const secretkey = process.env.SECRET_KEY ?? "";
const key = new TextEncoder().encode(secretkey)

export async function encrypt(payload: any) {
    const token = await new SignJWT(payload)
    .setProtectedHeader({alg:'HS256'})
    .setIssuedAt()
    .setIssuer(process.env.ISSUER ?? "")
    .setAudience(process.env.AUDIENCE ?? "")
    .setExpirationTime(Date.now()+60 * 60 * 24)
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
export async function login (prevState: any,data: any) {
    const expires = new Date(Date.now()+60 * 60 * 24*1000);
    const session = data;
    console.log(session);
    (await cookies()).set('session',session,{expires:expires,httpOnly:true})
  }

export async function register(prevState: any,data: any){
    const session = data
    console.log(session);
    const expires = new Date(Date.now()+60*60*1000*24);
    (await cookies()).set('session',session,{expires:expires,httpOnly:true})
}

export async function getSession(){
    const session = (await cookies()).get('session')?.value;
    if(!session) return null;
    const data = await decrypt(session)
    console.log(data)
    console.log(JSON.stringify(data))
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
        expires: new Date(Date.now() + 60 * 60 * 24*1000),
    });
    return res;
}