from django.urls import path

from . import views

app_name = 'products'
urlpatterns = [
	path('', views.index, name = 'index'),
	path('<int:product_id>/', views.detail, name = 'detail'),
	path('<int:product_id>/leave_review/', views.leave_review, name = 'leave_review'),
	path('post_products/', views.post_products, name = 'post_products'),
]