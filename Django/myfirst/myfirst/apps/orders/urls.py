from django.urls import path

from . import views

app_name = 'orders'
urlpatterns = [
	path('', views.index, name = 'index'),
	path('<int:order_id>/', views.detail, name = 'detail'),
	path('<int:order_id>/finish_order/', views.finish_order, name = 'finish_order'),
]