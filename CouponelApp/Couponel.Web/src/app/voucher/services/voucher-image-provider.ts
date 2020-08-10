import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class VoucherImageProvider {
  private categoryImages =
    {
      Food:             '../../assets/images/restaurant.svg',
      Auto:             '../../assets/images/auto.svg',
      Electronics:      '../../assets/images/electronics.svg',
      'Coffee&Snacks':  '../../assets/images/coffee.svg',
      Entertainment:    '../../assets/images/entertainment.svg',
      Fashion:          '../../assets/images/fashion.svg',
      Accessories:      '../../assets/images/accessories.svg',
      Home:             '../../assets/images/supplies.svg',
      Sport:            '../../assets/images/sport.svg',
      Others:           '../../assets/images/others.svg'
    };

  public getCategoryImage(category: string): string{
    const result = this.categoryImages[category];
    if (result == null)
    {
      console.log('Not Found Image for the category ' + category);
      return '../../assets/images/coupon.png';
    }
    return result;
  }
}
