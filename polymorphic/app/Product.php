<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Product extends Model
{
    //
    protected $table = 'product';
    protected $fillable = ['name'];
    public function photos() {
        return $this->morphMany('App\Photo','imageable');
    } 
}
