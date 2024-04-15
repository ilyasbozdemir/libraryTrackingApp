import { useFormik } from "formik";
import {
  FormControl,
  FormLabel,
  Input,
  VStack,
  Container,
  Stack,
  Heading,
  Center,
  Button,
  Text,
  useToast,
} from "@chakra-ui/react";

import * as Yup from "yup";
import AuthorService from "@/services/authorService";

export default function CreateAuthorForm() {
  const toast = useToast();

  const validationSchema = Yup.object().shape({
    name: Yup.string().required("Yazar Adı gereklidir."),
    surname: Yup.string().required("Yazar Soyadı gereklidir."),
    birthDate: Yup.date().required("Yazar Doğum Günü gereklidir."),
    country: Yup.string().required("Yazar Ülke Adı gereklidir."),
    biography: Yup.string().required("Yazar Biyografi gereklidir."),
  });

  const formik = useFormik({
    initialValues: {
      name: "",
      surname: "",
      birthDate: "",
      country: "",
      biography: "",
    },
    validationSchema,
    onSubmit: async (values) => {
      var data = JSON.stringify(values, null, 2);
      var result = await AuthorService.createAuthor(data);

      if (result.isSucces === true) {
        toast({
          title: "Başarı",
          description: "Yazar Kaydı Başarıyla Eklendi!",
          status: "success",
          duration: 5000,
          isClosable: true,
        });
      } else {
        toast({
          title: "Hata",
          description: result.messages,
          status: "error",
          duration: 5000,
          isClosable: true,
        });
      }
    },
  });

  return (
    <>
      <Container maxW="7xl" p={{ base: 5, md: 10 }}>
        <Center>
          <Stack spacing={4} w="100%">
            <Heading fontSize="2xl">Yeni Yazar Ekle</Heading>
            <VStack
              as="form"
              onSubmit={formik.handleSubmit}
              w="100%"
              spacing={8}
            >
              <FormControl id="name">
                <FormLabel>Name</FormLabel>
                <Input
                  type="text"
                  rounded="md"
                  onChange={formik.handleChange}
                  value={formik.values.name}
                  isInvalid={formik.touched.name && formik.errors.name}
                />
                {formik.touched.name && formik.errors.name && (
                  <Text color="red.500">{formik.errors.name}</Text>
                )}
              </FormControl>
              <FormControl id="surname">
                <FormLabel>Surname</FormLabel>
                <Input
                  type="text"
                  rounded="md"
                  onChange={formik.handleChange}
                  value={formik.values.surname}
                  isInvalid={formik.touched.surname && formik.errors.surname}
                />
                {formik.touched.surname && formik.errors.surname && (
                  <Text color="red.500">{formik.errors.surname}</Text>
                )}
              </FormControl>
              <FormControl id="birthDate">
                <FormLabel>Birth Date</FormLabel>
                <Input
                  type="date"
                  rounded="md"
                  onChange={formik.handleChange}
                  value={formik.values.birthDate}
                  isInvalid={
                    formik.touched.birthDate && formik.errors.birthDate
                  }
                />
                {formik.touched.birthDate && formik.errors.birthDate && (
                  <Text color="red.500">{formik.errors.birthDate}</Text>
                )}
              </FormControl>
              <FormControl id="country">
                <FormLabel>Country</FormLabel>
                <Input
                  type="text"
                  rounded="md"
                  onChange={formik.handleChange}
                  value={formik.values.country}
                  isInvalid={formik.touched.country && formik.errors.country}
                />
                {formik.touched.country && formik.errors.country && (
                  <Text color="red.500">{formik.errors.country}</Text>
                )}
              </FormControl>
              <FormControl id="biography">
                <FormLabel>Biyografi</FormLabel>
                <Input
                  as={"textarea"}
                  type="text"
                  rounded="md"
                  onChange={formik.handleChange}
                  value={formik.values.biography}
                  isInvalid={
                    formik.touched.biography && formik.errors.biography
                  }
                />
                {formik.touched.biography && formik.errors.biography && (
                  <Text color="red.500">{formik.errors.biography}</Text>
                )}
              </FormControl>
              <Button type="submit" colorScheme="blue">
                Submit
              </Button>
            </VStack>
          </Stack>
        </Center>
      </Container>
    </>
  );
}
