from django.http import Http404, HttpResponseRedirect
from django.shortcuts import render
from django.utils import timezone
from django.urls import reverse
from .models import Product

def index(request):
	latest_products_list = Product.objects.order_by('-id')[:5]
	return render(request, 'products/list.html', {'latest_products_list': latest_products_list})

def detail(request, product_id):
	try:
		a = Product.objects.get(id = product_id)
	except:
		raise Http404("Товар не найден")

	latest_reviews_list = a.review_set.order_by('-id')[:10]
	return render(request, 'products/detail.html', {'product': a, 'latest_reviews_list':latest_reviews_list})

def leave_review(request, product_id):
	try:
		a = Product.objects.get(id = product_id)
	except:
		raise Http404("Товар не найден")

	a.review_set.create(author_name = request.POST['name'], review_text = request.POST['text'], pub_date = timezone.now())
	return HttpResponseRedirect(reverse('products:detail', args = (a.id,)))

def post_products(request):
	a = Product(product_title = request.POST['name'], product_text = request.POST['longname'], product_price = request.POST['price'])
	a.save()
	return HttpResponseRedirect(reverse('products:index'))