from django.contrib import admin

# Register your models here.
from .models import Order, ProductSum

admin.site.register(ProductSum)
admin.site.register(Order)