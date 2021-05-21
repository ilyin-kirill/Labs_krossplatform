from django.contrib import admin
from django.urls import path, include

urlpatterns = [
	path('grappelli/', include('grappelli.urls')),
	path('orders/', include('orders.urls')),
	path('products/', include('products.urls')),
	path('admin/', admin.site.urls),
]