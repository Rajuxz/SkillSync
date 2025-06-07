import Sidebar from './Sidebar';
import { Outlet } from 'react-router';
const Layout = () => {
  return (
    <div className="flex flex-row bg-neutral-100 h-screen w-screen overflow-hidden">
      <Sidebar />
      <div className="p-4">
        <div>Header</div>
        {<Outlet />}
      </div>
    </div>
  );
};

export default Layout;
