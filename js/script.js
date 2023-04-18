var check = false;

changeTotal();
function changeVal(el) {
    
  var qt = parseFloat(el.parent().children(".qt").html());
    var qtty = document.getElementById('<%= TextBox1.ClientID %>').innerHTML;
    var qt = parseFloat(qtty)
    var qt = document.createElement("TextBox1").value();
    var price = parseFloat(el.parent().children(".price").html());
    var scharge = parseFloat(el.parent().children(".scharges").html());
    var eq = Math.round((price * qt * 100) / 100);
    
    el.parent().children(".full-price").html(eq + "&#8377;");

    changeTotal();
}

function changeTotal() {

    var price = 0;

    $(".full-price").each(function (index) {
        price += parseFloat($(".full-price").eq(index).html());
    });
   
    price = Math.round(price * 100) / 100;
    var tax = Math.round(price * 0.05 * 100) / 100
    var shipping = parseFloat($(".shipping span").html());
    var fullPrice = Math.round((price + tax + shipping) * 100) / 100;

    if (price == 0) {
        fullPrice = 0;
    }

    $(".subtotal span").html(price);
    $(".tax span").html(tax);
    $(".total span").html(price);
   
}

$(document).ready(function () {

    $(".remove").click(function () {
        var el = $(this);
        el.parent().parent().addClass("removed");
        window.setTimeout(
            function () {
                el.parent().parent().slideUp('fast', function () {
                    el.parent().parent().remove();
                    if ($(".product").length == 0) {
                        if (check) {
                            $("#cart").html("<h1>The shop does not function, yet!</h1><p>If you liked my shopping cart, please take a second and heart this Pen on <a href='https://codepen.io/ziga-miklic/pen/xhpob'>CodePen</a>. Thank you!</p>");
                        } else {
                            $("#cart").html("<h1>No products!</h1>");
                        }
                    }
                    changeTotal();
                });
            }, 200);
    });
    var i = 1;
    $(".qt-plus").click(function () {

       // var qtt = document.getElementById("TextBox1").value() += 1;
     //   alert(document.getElementById('TextBox1').max.value());
       // if (document.getElementById('TextBox1').max >= parseInt(i))
       //{
       //     document.getElementById('TextBox1').value = i++;
            
       // } else {
       //     alert("Invalid Quntity");
       // }

        document.createElement("TextBox1").value() + 1;
        $(this).parent().children(".qt").html(parseInt($(this).parent().children(".qt").html()) + 1);
       // document.getElementById('txt3').value  = parseInt($(this).parent().children(".qt").html()) + 1;
    
        $(this).parent().children(".full-price").addClass("added");
        
        var el = $(this);
        window.setTimeout(function () { el.parent().children(".full-price").removeClass("added"); changeVal(el); }, 10);


    });

    $(".qt-minus").click(function () {

        child = $(this).parent().children(".qt");

        if (parseInt(child.html()) > 1) {
            child.html(parseInt(child.html()) - 1);
        }

        $(this).parent().children(".full-price").addClass("minused");

        var el = $(this);

        var e2 = $(this);

        window.setTimeout(function () { el.parent().children(".full-price").removeClass("minused"); changeVal(el); }, 10);
        //var minuProductQty = document.getElementById('TextBox1').value;
        
        //if (document.getElementById('TextBox1').min < parseInt(minuProductQty)) {       
        //    minuProductQty--;
        //    document.getElementById('TextBox1').value = minuProductQty;
        ////console.log(document.getElementById('TextBox1'));
        //} else {
        //    alert("Invalid Quntity");
        //}

    });

   window.setTimeout(function () { $(".is-open").removeClass("is-open") }, 1200);

   
});