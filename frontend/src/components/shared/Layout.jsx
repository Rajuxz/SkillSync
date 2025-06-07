import Sidebar from './Sidebar'
import Header from './Header'
import { Outlet } from 'react-router'
import { useState } from 'react'
const Layout = () => {
  const [isSidebarOpen, setSidebarOpen] = useState(false)

  const handleToggle = () => {
    setSidebarOpen((prev) => !prev)
  }

  return (
    <div className="flex flex-row bg-neutral-100 h-screen w-screen overflow-hidden">
      <Sidebar isOpen={isSidebarOpen} />
      <div className="flex-1">
        <Header onToggleSidebar={handleToggle} isSidebarOpen={isSidebarOpen} />
        {<Outlet />}
      </div>
    </div>
  )
}

export default Layout
