import { Box, Flex } from "@chakra-ui/react";
import Head from "next/head";
import React from "react";

import Navbar from "../components/Admin/Navbar";
import Sidebar from "../components/Admin/Sidebar";

function AdminLayout({ children }) {
  return (
    <Flex as="main">
    <Head>
      <meta name="robots" content="noindex, nofollow" />
      <link rel="icon" href="/favicon.ico" />
    </Head>
    {
      /*
       <Sidebar />
    <Box w="100%">
      <Navbar />
      <Box m="10">{children}</Box>
    </Box>
      */
    }
   

    <Box m="10">{children}</Box>
  </Flex>
  );
}

export default AdminLayout;
