export const navigation = [
    {
        text: 'Главная',
        path: '/home',
        icon: 'home'
    },
    {
        text: 'Справочники',
        icon: 'folder',
        items: [
            {
                text: 'Покупатели',
                path: '/buyers'
            },
            {
                text: 'Товары',
                path: '/products',
            }
        ]
    }, 
    {
        text: 'Отчеты',
        icon: 'folder',
        items: [
            {
                text: 'Отчет за период',
                path: '/report',
                icon: 'folder'
            }
        ]
    }, 
  
];
