@extends('layouts.app')
@section('content')
    <h1>{{ $post->title }}</h1>
    <br>
    <a href="{{ route('posts.edit',$post ->id) }}">Edit</a>
@endsection