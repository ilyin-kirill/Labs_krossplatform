from django.http import Http404, HttpResponseRedirect, HttpResponse
from django.shortcuts import render
from django.utils import timezone
from .models import Order
from django.urls import reverse
from products.models import Product
from cloudipsp import Api, Checkout
# Create your views here.

def index(request):
	latest_orders_list = Order.objects.order_by('-id')[:5]
	return render(request, 'orders/list.html', {'latest_orders_list': latest_orders_list})

def detail(request, order_id):
	try:
		a = Order.objects.get(id = order_id)
	except:
		raise Http404("Заказ не найден")
	k=0
	for i in a.productsum_set.all():
		k+=i.product.product_price*i.amount
	latest_productsums_list = a.productsum_set.order_by('-id')[:10]
	return render(request, 'orders/detail.html', {'order': a, 'latest_productsums_list':latest_productsums_list, 'price':k})

def finish_order(request, order_id):
	try:
		a = Order.objects.get(id = order_id)
	except:
		raise Http404("Заказ не найден")
	k=0
	for i in a.productsum_set.all():
		k+=i.product.product_price*i.amount
	api = Api(merchant_id=1396424, secret_key='test')
	checkout = Checkout(api=api)
	data = {
    	"currency": "RUB",
    	"amount": k*100
	}
	url = checkout.url(data).get('checkout_url')
	return HttpResponseRedirect(url)
