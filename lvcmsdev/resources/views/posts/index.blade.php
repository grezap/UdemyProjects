@extends('layouts.app')
@section('content')
    <a href="{{ route('posts.create') }}">Add New Post</a>
    <ul>
        @foreach ($posts as $post)
            <div class="image-container">
                <img src="{{ $post->path }}" alt="">
            </div>
            <li><a href="{{ route('posts.show',$post ->id) }}">{{ $post ->title }}</a></li>
        @endforeach
    </ul>
@endsection
