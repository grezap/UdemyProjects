@extends('layouts.app')
@section('content')
    <form action="/posts" method="post">
        <input type="text" name="title" placeholder="enter title">
        <input type="text" name="content" placeholder="enter content">
        <input type="submit" name="submit">
    </form>
@endsection
