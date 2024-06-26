import {
  Link as CLink,
  Flex,
} from "@chakra-ui/react";


import React from "react";

const Footer = () => {


  return (
    <Flex justifyContent={'center'}>
    <FooterData/>
    </Flex>
  );
};


const FooterData = () => {
  const startYear = 2023;
  const currentYear = new Date().getFullYear();
  let yearText;
  if (currentYear > startYear) {
    yearText = `${startYear}-${currentYear}`;
  } else {
    yearText = `${startYear}`;
  }
  return <> {yearText} &copy; Tüm Hakları Saklıdır.</>;
};
export async function getStaticProps({ locale }) {
  return {
    props: {
      ...(await serverSideTranslations(locale, ["common"])),
    },
  };
}

export default React.memo(Footer);
