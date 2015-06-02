var app = require('../app.js');
var assert = require('assert')

describe('app', function(){
    it('should return hello', function(){
      assert.equal('HELLO',app.hello());
    })
})

