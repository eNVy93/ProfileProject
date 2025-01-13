// import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import BankStatementPage from './components/BankStatement/BankStatementPage'
import Home from './components/Home'
import Missions from './components/Missions/Missions';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/bankstatements',
    element: <BankStatementPage />
  },
  {
    path: '/missions',
    element: <Missions/>
  }
//   {
//     path: '/fetch-data',
//     requireAuth: true,
//     element: <FetchData />
//   },
//   ...ApiAuthorzationRoutes
];

export default AppRoutes;
