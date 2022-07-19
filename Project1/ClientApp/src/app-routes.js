import { HomePage, TasksPage, ProfilePage, BuyersPage, ProductsPage, BuyerPage, ReportPage } from './pages';
import { withNavigationWatcher } from './contexts/navigation';

const routes = [
    {
        path: '/tasks',
        element: TasksPage
    },
    {
        path: '/profile',
        element: ProfilePage
    },
    {
        path: '/home',
        element: HomePage
    },
    {
        path: '/buyers/:recId',
        element: BuyerPage
    },
    {
        path: '/buyers/new',
        element: BuyerPage
    },
    {
        path: '/buyers',
        element: BuyersPage
    },
    {
        path: '/products',
        element: ProductsPage
    }, 
  {
    path: '/report',
    element: ReportPage
  }
];

export default routes.map(route => {
    return {
        ...route,
        element: withNavigationWatcher(route.element, route.path)
    };
});
