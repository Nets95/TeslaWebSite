
function SetIMG(selected_url)
{
   var item = document.getElementById("Preview");
    item.src=selected_url;
}

$(document).ready(function(){
   $('#header').fadeTo(2000,0.3,function(){ 
       $('html, body').animate({ scrollTop: $('#content').offset().top }, 2000);
   });
});


$(document).on('submit','form',function(){
    
    var UserName=$('input[name=Name]').val();
    var UserTel=$('input[name=Tel]').val();
    var Car=$('select').val();
    
    if(UserName.length>0)
    {
  
    var regular=/[0-9]{3}[0-9]{3}[0-9]{4}/;
    if(regular.test(UserTel)==true)
    {
        alert('All good!');
     SubmitForm(UserName,UserTel,Car);
    }
    else
    {
        alert("Wrong phone number");
    }
    }
    else{
        alert("You forgot input your name");
    }
});


function SubmitForm(name,tel,car)
{
   $.ajax({
  method: "POST",
  url: "/Home/Form",
  data: { Name: name, Tel: tel, Car:car }
})
  .done(function( msg ) {
    alert( "Good: " + msg );
  }).fail(function() {
    alert( "Error oqured" );
  }); 
}

