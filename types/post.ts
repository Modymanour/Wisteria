interface Post{
    id: number,
    title: string;
    bio: string;
    tags: string[];
    reactions: {
        likes:number;
        dislikes:number;
    };
    views: number;
    userID: number;
}
// interface Post{ acctuall my backend interface
//     id: number,
//     title: string;
//     bio: string;
//     likes:number;
//     userID: number;
//     image:string;
// }