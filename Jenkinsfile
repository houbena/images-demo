pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                sh 'docker image build -t myapp:build-${env.BUILD_ID} .'
                sh 'docker image build --target testrunner -t myapp:testbuild-${env.BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:test-${env.BUILD_ID}'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker container run myapp:1.0-${env.BUILD_ID}'
            }
        }
    }
}
