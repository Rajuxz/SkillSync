import React from 'react'
import { HiOutlineSearch } from 'react-icons/hi'
import { IoMdMenu } from 'react-icons/io'
import { RxCross2 } from 'react-icons/rx'

import Logo from '../../assets/images/logo.png'
const Header = ({ onToggleSidebar, isSidebarOpen }) => {
  return (
    <div className="bg-white/65 h-16 px-4 w-full flex items-center justify-between border-b border-gray-200">
      <div className="md:hidden cursor-pointer" onClick={onToggleSidebar}>
        {isSidebarOpen ? (
          <RxCross2 fontSize={24} />
        ) : (
          <IoMdMenu fontSize={24} />
        )}
      </div>
      <div className="relative hidden md:flex">
        <HiOutlineSearch
          fontSize={24}
          className="absolute text-gray-400 top-1/2 -translate-y-1/2 left-3"
        />
        <input
          type="text"
          placeholder="Search..."
          id="searchForm"
          className="text-sm active:outline-none focus:outline-none h-10 w-[24rem] border border-gray-300 rounded pl-11 pr-4 "
        />
      </div>
      <div className="flex items-center justify-center flex-row gap-2">
        <div className="border border-gray-300 rounded-full">
          <img
            src={Logo}
            alt="Logo"
            className="h-10 rounded-full object-contain"
          />
        </div>
        <div>Hello, Robo !</div>
      </div>
    </div>
  )
}

export default Header
