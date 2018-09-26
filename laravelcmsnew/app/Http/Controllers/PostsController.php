<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use App\Http\Requests;
use App\Post;

class PostsController extends Controller
{
    //

    public function index(){
        dd(Post::get()->all());
        // $posts = array_merge(Post::all());
        // dd($posts);
        //return view('posts.index',compact('posts'));
    }

    public function store(Request $request){
        $post = new Post();
        $post->title=$request->title;
        $post->content = $request->content;
        $post->save();
        return redirect('/posts');
    }

    public function create(){
        return view('posts.create');
    }
}
