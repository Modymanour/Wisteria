
"use client";
import { Heart, MessageCircle, Share, Bookmark, Search, Bell } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import W from "@/app/letter-w.png";
import {Avatar, AvatarGroup, AvatarIcon} from "@heroui/avatar";
import Image from "next/image";

// Mock data for feed posts
const posts = [
  {
    id: 1,
    user: { name: "Alice Johnson", username: "alice_art", avatar: "/placeholder.svg" },
    image: "https://images.unsplash.com/photo-1541961017774-22349e4a1262?w=400&h=600&fit=crop",
    title: "Sunset over mountains",
    likes: 127,
    comments: 23,
    type: "art"
  },
  {
    id: 2,
    user: { name: "Music Maker", username: "beatdrop", avatar: "/placeholder.svg" },
    image: "https://images.unsplash.com/photo-1493225457124-a3eb161ffa5f?w=400&h=300&fit=crop",
    title: "New track: Midnight Dreams",
    likes: 89,
    comments: 15,
    type: "music"
  },
  {
    id: 3,
    user: { name: "Sarah Chen", username: "sarahpaints", avatar: "/placeholder.svg" },
    image: "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=400&h=500&fit=crop",
    title: "Abstract composition #3",
    likes: 203,
    comments: 34,
    type: "art"
  },
  {
    id: 4,
    user: { name: "Tom Rivera", username: "tomguitar", avatar: "/placeholder.svg" },
    image: "https://images.unsplash.com/photo-1511671782779-c97d3d27a1d4?w=400&h=400&fit=crop",
    title: "Acoustic session in the park",
    likes: 156,
    comments: 28,
    type: "music"
  },
  {
    id: 5,
    user: { name: "Maya Digital", username: "maya_creates", avatar: "/placeholder.svg" },
    image: "https://images.unsplash.com/photo-1547036967-23d11aacaee0?w=400&h=700&fit=crop",
    title: "Digital portrait series",
    likes: 445,
    comments: 67,
    type: "art"
  }
];

const Feed = () => {
  return (
    <div className="min-h-screen bg-gradient-to-br from-orange-50 via-white to-purple-50">
      {/*Header*/}
      <header className="sticky top-0 bg-white/80 backdrop-blur-sm border-b z-50">
        <div className="max-w-7xl mx-auto px-4 py-3">
          <div className="flex items-center justify-between">
            <div className="flex items-center space-x-4">
              <a href="/" className="flex items-center space-x-2">
                <Image
                src={W} 
                alt="Wisteria Logo"
                height={8}
                width={8} 
                ></Image>
                <span className="text-xl font-bold bg-gradient-to-r from-orange-500 to-purple-600 bg-clip-text text-transparent">Wisteria</span>
              </a>
            </div>
            
            <div className="flex-1 max-w-xl mx-4">
              <div className="relative">
                <Search className="absolute left-3 top-1/2 transform -translate-y-1/2 text-gray-400 w-4 h-4" />
                <Input 
                  placeholder="Search for art, music, or creators..." 
                  className="pl-10 border-gray-200 focus:border-orange-500 focus:ring-orange-500"
                />
              </div>
            </div>
            
            <div className="flex items-center space-x-4">
              <Button variant="ghost" size="sm" className="text-gray-600 hover:text-orange-600">
                <Bell className="w-5 h-5" />
              </Button>
              <a href="/profile">
                <Avatar showFallback name="YU" src="/placeholder.svg"/>
              </a>
            </div>
          </div>
        </div>
      </header>

      {/* Main Content */}
      <main className="max-w-7xl mx-auto px-4 py-6">
        <div className="masonry-grid">
          {posts.map((post) => (
            <div key={post.id} className="masonry-item">
              <div className="Post">
                <Image
                  src={post.image} 
                  alt={post.title}
                  width={30}
                  height={30}
                  className="image"
                />
                
                <div className="p-4">
                  <h3 className="titleText">{post.title}</h3>
                  
                  <div className="AvatarandName">
                    <div className="flex items-center space-x-2">
                      <Avatar showFallback name={post.user?.name?.charAt(0) ?? ""} className="w-8 h-8" src={post.user.avatar}/>
                      <div>
                        <p className="text-sm font-medium text-gray-800">{post.user?.name}</p>
                        <p className="text-xs text-gray-500">@{post.user?.username}</p>
                      </div>
                    </div>
                    
                    <div className="ButtonandBookmark">
                      <Button variant="ghost" size="sm" className="text-gray-500 hover:text-orange-600">
                        <Bookmark className="w-4 h-4" />
                      </Button>
                      <Button variant="ghost" size="sm" className="text-gray-500 hover:text-orange-600">
                        <Share className="w-4 h-4" />
                      </Button>
                    </div>
                  </div>
                  
                  <div className="flex items-center space-x-4 text-sm text-gray-500">
                    <div className="flex items-center space-x-1">
                      <Heart className="w-4 h-4" />
                      <span>{post.likes}</span>
                    </div>
                    <div className="flex items-center space-x-1">
                      <MessageCircle className="w-4 h-4" />
                      <span>{post.comments}</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
};

export default Feed;
