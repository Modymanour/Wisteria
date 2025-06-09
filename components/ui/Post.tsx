"use client";
import "@/app/feed/feed.css";
import { useEffect, useState } from "react";
import axios from "axios"
import { Heart, MessageCircle, Share, Bookmark, Search, Bell } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import W from "@/app/letter-w.png";
import {Avatar, AvatarGroup, AvatarIcon} from "@heroui/avatar";
import Image from "next/image";


export default function Post(){
    const url = 'https://dummyjson.com/posts/1';
    const [post,setPost] = useState({} as Post);
    const [user,setUser] = useState({} as User)
    const fetchPost = async () =>{
        try{
            const postResponse = await axios.get(url)
            setPost(postResponse.data)
            const userResponse = await axios.get(`https://dummyjson.com/users/${postResponse.data.userId}`)
            setUser(userResponse.data)
        }
        catch(error){
            console.log("error happened: ",error)
        }
        finally{

        }
    }

    useEffect( () =>{
        fetchPost()
    }, [])
    return(
        <div className="">
         <div key={post.id} className="masonry-item">
              <div className="post-card">
                <Image
                  src={W} 
                  alt={post.title ?? " "}
                  className="post-image"
                />
                <div className="post-content">
                  <h3 className="post-title">{post.title}</h3>
                  
                  <div className="post-header">
                    <div className="post-user">
                        {/* I left out the src for the avatar for now */}
                      <Avatar showFallback name={user?.firstName?.charAt(0) ?? ""} className="avatar" />
                      <div className="user-info">
                        <p className="user-name">{user?.firstName} {user?.lastName}</p>
                        <p className="user-handle">@{user?.username}</p>
                      </div>
                    </div>
                    
                    <div className="post-actions">
                      <Button variant="ghost" size="sm" className="action-button">
                        <Bookmark className="action-icon" />
                      </Button>
                      <Button variant="ghost" size="sm" className="action-button">
                        <Share className="action-icon" />
                      </Button>
                    </div>
                  </div>
                  
                  <div className="post-stats">
                    <div className="stat">
                      <Heart className="stat-icon" />
                      <span>{post.reactions?.likes ?? ""}</span>
                    </div>
                    <div className="stat">
                      <MessageCircle className="stat-icon" />
                      {/* <span>{post.comments}</span> */}
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
    )
}