function write(message)
{
  document.getElementById('message').innerHTML+=message+'<br/>';
}


function calculateCircumference(diameter)
{
  return diameter*Math.PI;
}

write(calculateCircumference(5).toFixed(6));


write(write.toString());

var point=new Object();

point.x=10;
point.y=20;

point.sum= function ()
{
   return point.x+point.y;
};



point.toString=function()
{
  return "x="+point.x+ ' y= '+ point.y+ ' sum='+point.sum();
};

write(point.toString());


//arguments

function sumArgs()
{
  var total=0;
  for(var i=0;i<arguments.length;i++)
    {
      total+=arguments[i];
    }
  return total;
};

write(sumArgs());
write(sumArgs(1,2,3));
write(sumArgs(1,2,3,4));


//recursion



function factorial(n)
{
  if(n===0||n===1)
    {
      return 1;
    }
  return n*factorial(n-1);
}

write(factorial(5));


//switch


function location(l)
{
  switch(l)
    {
      case "iasi":
        write("Location is Iasi");
        break;
      case "cluj":
        write("Location is cluj");
        break;
      default :
        write("Location "+l+" is not present");
        break;
    }
}


location("iasi");
location("cluj");
location("Arad");


//handle errors


function eerr()
{

  write("after err");
  
}


try{
 eerr();
    throw {
        name:"Erorr",
        message: "An error."
  };
  
}
catch(e)
  {
    write(e.name +e.message);
  }
